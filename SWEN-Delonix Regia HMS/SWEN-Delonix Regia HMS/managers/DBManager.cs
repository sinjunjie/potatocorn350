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

        public void UpdateStaff(int staffId, string firstName, string lastName, DateTime dateOfBirth, string bankAccountNumber, string staffAddress, int phoneNumber, int dutyId, int accountId )
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
        public void DeleteGuest(int guestId)
        {
            cmd.CommandText = "DELETE FROM Guest WHERE guestId=@guestId";
            cmd.Parameters.AddWithValue("@guestId", guestId);

            cmd.ExecuteNonQuery();

        }
    }
}
