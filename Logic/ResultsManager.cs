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
            resultsManager.UpdateParPoints();

            cmd = new SqlCommand("SELECT * FROM Participants Order by parPoints DESC", conn);
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
                data.parRaceTime = Convert.ToInt32(reader["parRaceTime"]);
                data.parPoints = Convert.ToInt32(reader["parPoints"]);
                result.Add(data);
            }

            reader.Close();

            return result;
        }

        public void UpdateParPoints()
        {
            ResultsManager resultsManager = new ResultsManager();
            List<string> ageGroupList = new List<string>();
            /*  {
                    "V 3", "V 5", "V 7", "V 9", "V 10", "V 12", "V 14", "V 16", "V 18", "V 20", "V 21", "V 35", "V 40", "V 45", "V 50", "V 55", "V 60", "V 65", "V 70", "V 75", "V 80",
                    "S 3", "S 5", "S 7", "S 9", "S 10", "S 12", "S 14", "S 16", "S 18", "S 20", "S 21", "S 35", "S 40", "S 45", "S 50", "S 55", "S 60", "S 65", "S 70", "S 75", "S 80"
                }; */

            ageGroupList = resultsManager.GetAgeGroupList();

            foreach (string item in ageGroupList)
            {
                int groupWinnerTime = resultsManager.GetAgeGroupWinnerTime(item);

                List<ParticipantsData> participants = new List<ParticipantsData>();

                participants = resultsManager.SelectAllParticipantsByAgeGroup(item);

                foreach (var data in participants)
                {
                    double points = Convert.ToDouble(groupWinnerTime) / Convert.ToDouble(data.parRaceTime) * 1000;
                    int pointsToUpload = Convert.ToInt32(points);
                    cmd = new SqlCommand("UPDATE Participants SET parPoints = @p1 WHERE id = @p2", conn);
                    cmd.Parameters.Add("@p1", SqlDbType.Int).Value = pointsToUpload;
                    cmd.Parameters.Add("@p2", SqlDbType.Int).Value = data.Id;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public int GetAgeGroupWinnerTime(string parAgeGroup)
        {
            int groupWinnerTime = 0;

            cmd = new SqlCommand("SELECT TOP 1 parRaceTime FROM Participants WHERE parAgeGroup = @p1 Order BY parRaceTime ASC", conn);
            cmd.Parameters.Add("@p1", SqlDbType.VarChar).Value = parAgeGroup;

            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader["parRaceTime"] != DBNull.Value)
            {
                groupWinnerTime = Convert.ToInt32(reader["parRaceTime"]);
            }

            reader.Close();

            return groupWinnerTime;
        }

        public List<ParticipantsData> SelectAllParticipantsByAgeGroup(string parAgeGroup)
        {
            cmd = new SqlCommand("SELECT * FROM Participants WHERE parAgeGroup = @p1", conn);
            cmd.Parameters.Add("@p1", SqlDbType.VarChar).Value = parAgeGroup;
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
                data.parRaceTime = Convert.ToInt32(reader["parRaceTime"]);
                data.parPoints = Convert.ToInt32(reader["parPoints"]);
                result.Add(data);
            }

            reader.Close();

            return result;
        }

        public List<string> GetAgeGroupList()
        {
            cmd = new SqlCommand("SELECT DISTINCT parAgeGroup FROM Participants; ", conn);
            reader = cmd.ExecuteReader();

            List<string> result = new List<string>();
            while (reader.Read())
            {
                string parAgeGroup = Convert.ToString(reader["parAgeGroup"]);

                result.Add(parAgeGroup);
            }
            reader.Close();

            return result;
        }

    }
}
