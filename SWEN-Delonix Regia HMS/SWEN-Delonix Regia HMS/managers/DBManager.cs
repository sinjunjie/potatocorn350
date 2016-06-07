using SWEN_Delonix_Regia_HMS.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWEN_Delonix_Regia_HMS.managers
{
    class DBManager
    {
        public string connectionString = "Server=woodmon122.duckdns.org;Database=JunjieDB;User=swen;Password=swen";

        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public DBManager()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            cmd.Connection = conn;
        }

        public int DoLogin(string username, string password)
        {
            cmd.CommandText = "SELECT password FROM [dbo].[Account] WHERE username=@username"; //See this line ah
            cmd.Parameters.AddWithValue("@username", username);
            string retrievedPassword = Convert.ToString(cmd.ExecuteScalar()); //This is the password that the SQL query retrieved

            if (retrievedPassword.Equals(password))//I compare it with the input password
            {
                return 1; //return 1 here to note that the password is correct ,and the user should be logged in
            }
            else//Login failed
            {
                return 0; // return 0 here to note that the password is wrong
            }
        }

        public List<Duty> GetAllDuties()
        {
            cmd.CommandText = "SELECT * FROM Duty";

            List<Duty> tempList = new List<Duty>();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Duty d = new Duty()
                {
                    dutyId = Convert.ToInt32(dr[0]),
                    dutyType = (string)dr[1],
                };
                tempList.Add(d);
            }

            dr.Close();
            conn.Close();

            return tempList;
        }


        public void UpdateDuty(int dutyId, string toUpdate)
        {
            cmd.CommandText = "UPDATE Duty SET [dutyType] = @toUpdate WHERE dutyId=@dutyId";
            cmd.Parameters.AddWithValue("@dutyId", dutyId);
            cmd.Parameters.AddWithValue("@toUpdate", toUpdate);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStaff(int staffId, string firstName, string lastName, DateTime dateOfBirth, string bankAccountNumber, string staffAddress, int phoneNumber, int dutyId, int accountId)
        {
            cmd.CommandText = "UPDATE HotelStaff SET [firstName] = @firstName,[lastName] = @lastName,[dateOfBirth] = @dateOfBirth,[bankAccountNumber] = @bankAccountNumber,[staffAddress] = @staffAddress,[phoneNumber] = @phoneNumber, [dutyId] = @dutyId, [accountId] = @accountId  WHERE staffId=@staffId";
            cmd.Parameters.AddWithValue("@staffId", staffId);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@bankAccountNumber", bankAccountNumber);
            cmd.Parameters.AddWithValue("@staffAddress", staffAddress);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@dutyId", dutyId);
            cmd.Parameters.AddWithValue("@accountId", accountId);
            cmd.ExecuteNonQuery();
        }

        public void InsertStaff(int staffId,string firstName, string lastName, DateTime dateOfBirth, string bankAccountNumber, string staffAddress, int phoneNumber, int dutyId, int accountId)
        {
            cmd.CommandText = "INSERT INTO [dbo].[HotelStaff]([firstName],[lastName],[dateOfBirth],[bankAccountNumber],[staffAddress],[phoneNumber],[dutyId],[accountId]) VALUES (@firstName,@lastName,@dateOfBirth,@bankAccountNumber,@staffAddress,@phoneNumber,@dutyId,@accountId)";
            cmd.Parameters.AddWithValue("@staffId", staffId);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@bankAccountNumber", bankAccountNumber);
            cmd.Parameters.AddWithValue("@staffAddress", staffAddress);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@dutyId", dutyId);
            cmd.Parameters.AddWithValue("@accountId", accountId);
            cmd.ExecuteNonQuery();

        }

        public void DeleteStaff(int staffId)
        {
            cmd.CommandText = "DELETE FROM HotelStaff WHERE staffId=@staffId";
            cmd.Parameters.AddWithValue("@staffId", staffId);

            cmd.ExecuteNonQuery();

        }

        public List<Staff> GetStaffById(int staffId)
        {
            cmd.CommandText = "SELECT * FROM HotelStaff WHERE staffId=@staffId";
            cmd.Parameters.AddWithValue("@staffId", staffId);

            List<Staff> tempList = new List<Staff>();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Staff d = new Staff()
                {
                    staffId = (int)dr[0],
                    firstName = (string)dr[1],
                    lastName = (string)dr[2],
                    dateOfBirth = (DateTime)dr[3],
                    bankAccountNumber = (string)dr[4],
                    staffAddress = (string)dr[5],
                    phoneNumber = (int)dr[6],
                    dutyId = (int)dr[7],
                    accountId = (int)dr[8],
                };
                tempList.Add(d);
            }

            dr.Close();
            conn.Close();

            return tempList;
        }

        public List<Guest> GetGuestById(int guestId)
        {
            cmd.CommandText = "SELECT * FROM Guest WHERE guestId=@guestId";
            cmd.Parameters.AddWithValue("@guestId", guestId);

            List<Guest> tempList = new List<Guest>();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Guest d = new Guest()
                {
                    guestId = (int)dr[0],
                    firstName = (string)dr[1],
                    lastName = (string)dr[2],
                    phoneNum = (int)dr[3],
                    email = (string)dr[4],
                    guestAddress = (string)dr[5],
                    country = (string)dr[6],

                };
                tempList.Add(d);
            }

            dr.Close();
            conn.Close();

            return tempList;
        }
        public void UpdateGuest(int guestId, string firstName, string lastName, int phoneNum, string email, string guestAddress, string country)
        {
            cmd.CommandText = "UPDATE [dbo].[Guest] SET [firstName] = @firstName, [lastName] = @lastName,[phoneNum] = @phoneNum,[email] = @email,[guestAddress] = @guestAddress ,[country] = @country WHERE guestId = @guestId";
            cmd.Parameters.AddWithValue("@guestId", guestId);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@phoneNum", phoneNum);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@guestAddress", guestAddress);
            cmd.Parameters.AddWithValue("@country", country);

            cmd.ExecuteNonQuery();

            conn.Close();

        }
        public void InsertGuest(string firstName, string lastName, int phoneNum, string email, string guestAddress, string country)
        {
            cmd.CommandText = "INSERT INTO [dbo].[Guest]([firstName],[lastName],[phoneNum],[email],[guestAddress],[country]) VALUES (@firstName,@lastName,@phoneNum,@email,@guestAddress,@country)";
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@phoneNum", phoneNum);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@guestAddress", guestAddress);
            cmd.Parameters.AddWithValue("@country", country);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Room> GetRoomPrice()
        {
            cmd.CommandText = "SELECT DISTINCT FROM Room WHERE roomPrice=@roomPrice";

            List<Room> tempList = new List<Room>();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Room d = new Room()
                {
                    roomPrice = Convert.ToInt32(dr[0]),                
                };
                tempList.Add(d);
            }

            dr.Close();
            conn.Close();

            return tempList;
        }
        public List<Room> GetRoomStatus(string roomStatus)
        {
            cmd.CommandText = "SELECT COUNT(*) FROM Room WHERE roomStatus = 'Available'";
            cmd.Parameters.AddWithValue("@roomStatus", roomStatus);

            List<Room> tempList = new List<Room>();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Room d = new Room()
                {
                    roomStatus = (string)dr[0]
                 

                };
                tempList.Add(d);
            }

            dr.Close();
            conn.Close();

            return tempList;
        }
        public void DeleteGuest(int guestId)
        {
            cmd.CommandText = "DELETE FROM Guest WHERE guestId=@guestId";
            cmd.Parameters.AddWithValue("@guestId", guestId);

            cmd.ExecuteNonQuery();

        }

        public void CreateAccount(string username, string password, Boolean isAdmin)
        {
            cmd.CommandText = "INSERT INTO [dbo].[Account]([username],[password],[isAdmin]) VALUES (@username,@password,@isAdmin)";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@isAdmin", isAdmin);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Account> GetAccountById(int accountId)
        {
            cmd.CommandText = "SELECT * FROM Account WHERE accountId=@accountId";
            cmd.Parameters.AddWithValue("@accountId", accountId);

            List<Account> tempList = new List<Account>();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Account d = new Account()
                {
                    accountId = (int)dr[0],
                    username = (string)dr[1],
                    password = (string)dr[2],
                    isAdmin = (int)dr[3],
                };
                tempList.Add(d);
            }

            dr.Close();
            conn.Close();

            return tempList;
        }

        public void UpdateAccount(int accountId, string username, string password, Boolean isAdmin)
        {
            cmd.CommandText = "UPDATE [dbo].[Account] SET [username] = @username, [password] = @password,[isAdmin] = @isAdmin WHERE accountId = @accountId";
            cmd.Parameters.AddWithValue("@accountId", accountId);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@isAdmin", isAdmin);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void DeleteAccount(int accountId)
        {
            cmd.CommandText = "DELETE FROM Account WHERE accountId=@accountId";
            cmd.Parameters.AddWithValue("@accountId", accountId);

            cmd.ExecuteNonQuery();

        }
    }
}
