using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Data;

namespace Logic
{
    public class ResultsManager : BaseManeger
    {
        public List<ParticipantsData> SelectAllParticipants()
        {
            ResultsManager resultsManager = new ResultsManager();

            cmd = new SqlCommand("SELECT * FROM Participants Order by parPointsSum DESC", conn);
            reader = cmd.ExecuteReader();

            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parPoints1 = Convert.ToInt32(reader["parPoints1"]);
                data.parPoints2 = Convert.ToInt32(reader["parPoints2"]);
                data.parPoints3 = Convert.ToInt32(reader["parPoints3"]);
                data.parPoints4 = Convert.ToInt32(reader["parPoints4"]);
                data.parPoints5 = Convert.ToInt32(reader["parPoints5"]);
                data.parPoints6 = Convert.ToInt32(reader["parPoints6"]);
                data.parPoints7 = Convert.ToInt32(reader["parPoints7"]);
                data.parPoints8 = Convert.ToInt32(reader["parPoints8"]);
                data.parPointsSum = Convert.ToInt32(reader["parPointsSum"]);
                result.Add(data);
            }
            reader.Close();

            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage1()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime1, parPoints1 FROM Participants Order by parPoints1 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime1 = Convert.ToInt32(reader["parRaceTime1"]);
                if (data.parRaceTime1 == 999999999) { data.parRaceTime1 = 0; }
                data.parPoints1 = Convert.ToInt32(reader["parPoints1"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage2()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime2, parPoints2 FROM Participants Order by parPoints2 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime2 = Convert.ToInt32(reader["parRaceTime2"]);
                if (data.parRaceTime2 == 999999999) { data.parRaceTime2 = 0; }
                data.parPoints2 = Convert.ToInt32(reader["parPoints2"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage3()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime3, parPoints3 FROM Participants Order by parPoints3 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime3 = Convert.ToInt32(reader["parRaceTime3"]);
                if (data.parRaceTime3 == 999999999) { data.parRaceTime3 = 0; }
                data.parPoints3 = Convert.ToInt32(reader["parPoints3"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage4()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime4, parPoints4 FROM Participants Order by parPoints4 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime4 = Convert.ToInt32(reader["parRaceTime4"]);
                if (data.parRaceTime4 == 999999999) { data.parRaceTime4 = 0; }
                data.parPoints4 = Convert.ToInt32(reader["parPoints4"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage5()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime5, parPoints5 FROM Participants Order by parPoints5 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime5 = Convert.ToInt32(reader["parRaceTime5"]);
                if (data.parRaceTime5 == 999999999) { data.parRaceTime5 = 0; }
                data.parPoints5 = Convert.ToInt32(reader["parPoints5"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage6()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime6, parPoints6 FROM Participants Order by parPoints6 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime6 = Convert.ToInt32(reader["parRaceTime6"]);
                if (data.parRaceTime6 == 999999999) { data.parRaceTime6 = 0; }
                data.parPoints6 = Convert.ToInt32(reader["parPoints6"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage7()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime7, parPoints7 FROM Participants Order by parPoints7 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime7 = Convert.ToInt32(reader["parRaceTime7"]);
                if (data.parRaceTime7 == 999999999) { data.parRaceTime7 = 0; }
                data.parPoints7 = Convert.ToInt32(reader["parPoints7"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }

        public List<ParticipantsData> SelectAllParticipantsForStage8()
        {
            cmd = new SqlCommand("SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime8, parPoints8 FROM Participants Order by parPoints8 DESC", conn);
            reader = cmd.ExecuteReader();
            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToString(reader["parAgeGroup"]);
                data.parRaceTime8 = Convert.ToInt32(reader["parRaceTime8"]);
                if (data.parRaceTime8 == 999999999) { data.parRaceTime8 = 0; }
                data.parPoints8 = Convert.ToInt32(reader["parPoints8"]);
                result.Add(data);
            }
            reader.Close();
            return result;
        }
    }
}
