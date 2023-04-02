using Oracle.ManagedDataAccess.Client;
using proiect10.tabele;
using proiect10.tabeleEx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect10
{
    public class Conexiune
    {
        private readonly string connectionString = "Provider= ORAOLEDB.ORACLE;Data Source=XE;User ID=student231;Password=studnikola231;Unicode=True";

        public string InsertVehicul(Vehicul Vehicul)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO VEHICUL (nr_vehicul, marca, tip, serie_motor, serie_caroserie, carburant, culoare, capacitate_cil) VALUES (:val1, :val2, :val3, :val4, :val5, :val6, :val7, :val8)";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = Vehicul.nrVehicul;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = Vehicul.marca;
                command.Parameters.Add(":val3", OracleDbType.Varchar2).Value = Vehicul.tip;
                command.Parameters.Add(":val4", OracleDbType.Int32).Value = Vehicul.serieMotor;
                command.Parameters.Add(":val5", OracleDbType.Int32).Value = Vehicul.serieCaroserie;
                command.Parameters.Add(":val6", OracleDbType.Varchar2).Value = Vehicul.carburant;
                command.Parameters.Add(":val7", OracleDbType.Varchar2).Value = Vehicul.culoare;
                command.Parameters.Add(":val8", OracleDbType.Int32).Value = Vehicul.capacitateCil;



                command.ExecuteNonQuery();
                return "Vehicul este adaugat cu success!!!!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string InsertPersoana(Persoana Persoana)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO PERSOANA (nume, prenume, carte_identitate, cnp, adresa, varsta) VALUES (:val1, :val2, :val3, :val4, :val5, :val6)";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = Persoana.nume;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = Persoana.prenume;
                command.Parameters.Add(":val3", OracleDbType.Int32).Value = Persoana.carteIdentitate;
                command.Parameters.Add(":val4", OracleDbType.Int64).Value = Persoana.cnp;
                command.Parameters.Add(":val5", OracleDbType.Varchar2).Value = Persoana.adresa;
                command.Parameters.Add(":val6", OracleDbType.Int32).Value = Persoana.varsta;
               



                command.ExecuteNonQuery();
                return "Persoana este adaugata cu success!!!!";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string InsertProprietate(Proprietate Proprietate)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO PROPRIETATE (cnp, nr_vehicol, data_cumpararii, pret) VALUES (:val1, :val2, :val3, :val4)";

                command.Parameters.Add(":val1", OracleDbType.Int32).Value = Proprietate.cnp;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = Proprietate.nrVehicol;
                command.Parameters.Add(":val3", OracleDbType.Date).Value = Convert.ToDateTime(Proprietate.dataCumparari);
                command.Parameters.Add(":val4", OracleDbType.Int32).Value = Proprietate.pret;

                command.ExecuteNonQuery();
                return "Persoana este adaugata cu success!!!!";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string InsertTipMasina(tipMasina tipMasina)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TIP_MASINA (tip, comentatarii ) VALUES (:val1, :val2)";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = tipMasina.tip;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = tipMasina.comentarii;

                command.ExecuteNonQuery();
                return "Persoana este adaugata cu success!!!!";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public ICollection<Vehicul> GetVehicul()
        {
            ICollection<Vehicul> Vehicul = new Collection<Vehicul>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM VEHICUL", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Vehicul.Add(new Vehicul
                    {
                        nrVehicul = reader.GetString(0),
                        marca = reader.GetString(1),
                        tip = reader.GetString(2),
                        serieMotor = Convert.ToInt32(reader.GetDecimal(3)),
                        serieCaroserie = Convert.ToInt32(reader.GetDecimal(4)),
                        carburant= reader.GetString(5),
                        culoare = reader.GetString(6),
                        capacitateCil = Convert.ToInt32(reader.GetDecimal(7))

                    });
                }

                return Vehicul;
            }
            catch
            {
                return Vehicul;
            }
        }


        public ICollection<Persoana> GetPersoana()
        {
            ICollection<Persoana> Persoane = new Collection<Persoana>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM PERSOANA", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Persoane.Add(new Persoana
                    {
                        nume = reader.GetString(0),
                        prenume = reader.GetString(1),
                        carteIdentitate = Convert.ToInt32(reader.GetDecimal(2)),
                        cnp = Convert.ToInt64(reader.GetDecimal(3)),
                        adresa = reader.GetString(4),
                        varsta = Convert.ToInt32(reader.GetDecimal(5))


                    });

                }

                return Persoane;
            }
            catch
            {
                return Persoane;
            }
        }



        public ICollection<Proprietate> GetProprietate()
        {
            ICollection<Proprietate> Proprietati= new Collection<Proprietate>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM PROPRIETATE", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Proprietati.Add(new Proprietate
                    //{
                    //    cnp = Convert.ToInt64(reader.GetDecimal(0)),
                    //    nrVehicol = reader.GetString(1),
                    //    dataCumparari= reader.GetString(2),
                    //    pret = Convert.ToInt32(reader.GetDecimal(3))

                    //});

                    Proprietate proprietate = new Proprietate();
                    proprietate.cnp = Convert.ToInt64(reader.GetDecimal(0));
                    proprietate.nrVehicol = reader.GetString(1);
                    proprietate.dataCumparari = Convert.ToString(reader.GetDateTime(2));
                    proprietate.pret = Convert.ToInt32(reader.GetDecimal(3));

                    Proprietati.Add(proprietate);
                }

                return Proprietati;
            }
            catch
            {
                return Proprietati;
            }
        }


        public ICollection<tipMasina> GetTipMasina()
        {
            ICollection<tipMasina> tipMasina= new Collection<tipMasina>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM TIP_MASINA", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tipMasina.Add(new tipMasina
                    {
                        tip = reader.GetString(0),
                        comentarii = reader.GetString(1)
                        

                    });
                }

                return tipMasina;
            }
            catch
            {
                return tipMasina;
            }
        }

        public string DeleteVehicul(string nrVehicul)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM VEHICUL WHERE nr_vehicul = :val1";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = nrVehicul;
                command.ExecuteNonQuery();
                return "Vehiculul este sters cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string DeletePersoana(int cnp)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM PERSOANA WHERE cnp = :val1";

                command.Parameters.Add(":val1", OracleDbType.Int32).Value = cnp;
                command.ExecuteNonQuery();
                return "Persaona este sters cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string DeleteProprietate(long cnp)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM PROPRIETATE WHERE cnp = :val1";

                command.Parameters.Add(":val1", OracleDbType.Int32).Value = cnp;
                command.ExecuteNonQuery();
                return "Proprietatea este stersa cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteTipMasina(string tip)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM TIP_MASINA WHERE tip = :val1";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = tip;
                command.ExecuteNonQuery();
                return "Tip masina este stersa cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string UpdateVehicul(Vehicul Vehicul)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE VEHICUL SET NR_VEHICUL = :val1, MARCA= :val2, TIP = :val3, SERIE_MOTOR = :val4, SERIE_CAROSERIE = :val5, CARBURANT = :val6, CULOARE = :val7, CAPACITATE_CIL = :val8 WHERE NR_VEHICUL = :val1";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = Vehicul.nrVehicul;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = Vehicul.marca;
                command.Parameters.Add(":val3", OracleDbType.Varchar2).Value = Vehicul.tip;
                command.Parameters.Add(":val4", OracleDbType.Int32).Value = Vehicul.serieMotor;
                command.Parameters.Add(":val5", OracleDbType.Int32).Value = Vehicul.serieCaroserie;
                command.Parameters.Add(":val6", OracleDbType.Varchar2).Value = Vehicul.carburant;
                command.Parameters.Add(":val7", OracleDbType.Varchar2).Value = Vehicul.culoare;
                command.Parameters.Add(":val8", OracleDbType.Int32).Value = Vehicul.capacitateCil;

                command.ExecuteNonQuery();

                return "Vehicul este actualizat cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdatePersoana(Persoana Persoana)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE PERSOANA SET NUME = :val1, PRENUME = :val2, CARTE_IDENTITATE = :val3, CNP = :val4, ADRESA = :val5, VARSTA = :val6 WHERE CNP = :val4";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = Persoana.nume;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = Persoana.prenume;
                command.Parameters.Add(":val3", OracleDbType.Int32).Value = Persoana.carteIdentitate;
                command.Parameters.Add(":val4", OracleDbType.Int64).Value = Persoana.cnp;
                command.Parameters.Add(":val5", OracleDbType.Varchar2).Value = Persoana.adresa;
                command.Parameters.Add(":val6", OracleDbType.Int32).Value = Persoana.varsta;
                
                command.ExecuteNonQuery();
                return "Persoana este actualizata cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateProprietate(Proprietate Proprietate)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE PROPRIETATE SET CNP = :val1, NR_VEHICOL = :val2, DATA_CUMPARARII = :val3, PRET = :val4 WHERE CNP = :val1";

                command.Parameters.Add(":val1", OracleDbType.Int32).Value = Proprietate.cnp;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = Proprietate.nrVehicol;
                command.Parameters.Add(":val3", OracleDbType.Varchar2).Value = Proprietate.dataCumparari;
                command.Parameters.Add(":val4", OracleDbType.Int32).Value = Proprietate.pret;
               
                command.ExecuteNonQuery();
                return "Proprietatea este actualizata cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string UpdateTipMasina(tipMasina tipMasina)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE TIP_MASINA SET TIP = :val1, comentatarii  = :val2 WHERE TIP = :val1";

                command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = tipMasina.tip;
                command.Parameters.Add(":val2", OracleDbType.Varchar2).Value = tipMasina.comentarii;
                

                command.ExecuteNonQuery();
                return "Tip masina este actualizata cu success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



        public ICollection<Ex2> GetEx2()
        {
            ICollection<Ex2> Ex2 = new Collection<Ex2>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("select V.Marca, count(V.MARCA) AS NUMAR_MASINI_MARCA, COUNT(DISTINCT V.MARCA) AS NUMAR_MARCI from Vehicul V group by V.MARCA", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ex2.Add(new Ex2
                    {
                        marca = reader.GetString(0),
                        numarMasini = Convert.ToInt32(reader.GetDecimal(1)),
                        nrMarci = Convert.ToInt32(reader.GetDecimal(2))
                    });
                }

                return Ex2;
            }
            catch (Exception e)
            {
                return Ex2;
            }
        }

        public ICollection<Ex3> GetEx3()
        {
            ICollection<Ex3> Ex3 = new Collection<Ex3>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("select V.MARCA, SUM(P.PRET) FROM VEHICUL V JOIN PROPRIETATE P ON V.nr_vehicul = P.nr_vehicol GROUP BY V.MARCA", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ex3.Add(new Ex3
                    {
                        marca = reader.GetString(0),
                        pret = Convert.ToInt32(reader.GetDecimal(1))
                        
                    });
                }

                return Ex3;
            }
            catch (Exception e)
            {
                return Ex3;
            }
        }

        public ICollection<Ex4> GetEx4(string marca)
        {
            ICollection<Ex4> Ex4 = new Collection<Ex4>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("select COUNT(V.marca), avg(P.pret) from vehicul V JOIN PROPRIETATE P ON V.nr_vehicul = P.nr_vehicol where V.marca = 'BMW' group by V.marca", connection);
                //command.Parameters.Add(":val1", OracleDbType.Varchar2).Value = marca;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ex4.Add(new Ex4
                    {
                        nrMarca = Convert.ToInt32(reader.GetDecimal(0)),
                        pret = Convert.ToInt32(reader.GetDecimal(1))

                    });
                }

                return Ex4;
            }
            catch (Exception e)
            {
                return Ex4;
            }
        }


        public ICollection<Ex5> GetEx5()
        {
            ICollection<Ex5> Ex5 = new Collection<Ex5>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("select V.NR_VEHICUL, V.MARCA, PR.PRET, P.NUME, P.PRENUME FROM VEHICUL V JOIN PROPRIETATE PR ON V.NR_VEHICUL = PR.NR_VEHICOL JOIN PERSOANA P ON P.CNP = PR.CNP AND PR.PRET = (SELECT MAX(PR.PRET) FROM PROPRIETATE PR)  GROUP BY V.NR_VEHICUL, V.MARCA, PR.PRET, P.NUME, P.PRENUME", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ex5.Add(new Ex5
                    {
                        nrVehicule = reader.GetString(0),
                        marca = reader.GetString(1),
                        pret = Convert.ToInt32(reader.GetDecimal(2)),
                        nume = reader.GetString(3),
                        prenume = reader.GetString(4)

                    });
                }

                return Ex5;
            }
            catch (Exception e)
            {
                return Ex5;
            }
        }

        public ICollection<Ex6> GetEx6()
        {
            ICollection<Ex6> Ex6 = new Collection<Ex6>();
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from Persoana where varsta <= 30 and varsta >= 20", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ex6.Add(new Ex6
                    {
                        nume = reader.GetString(0),
                        prenume = reader.GetString(1),
                        carteIdentitate = Convert.ToInt32(reader.GetDecimal(2)),
                        cnp = Convert.ToInt64(reader.GetDecimal(3)),
                        adresa = reader.GetString(4),
                        varsta = Convert.ToInt32(reader.GetDecimal(5))


                    });
                }

                return Ex6;
            }
            catch (Exception e)
            {
                return Ex6;
            }
        }



    }
}
