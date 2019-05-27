using Logic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PointsManager : BaseManeger
    {
        public void UpdateParPoints()
        {
            PointsManager pointsManager = new PointsManager();

            List<string> ageGroupList = new List<string>();
            ageGroupList = pointsManager.GetAgeGroupList();

            foreach (string ageGroup in ageGroupList)
            {
                List<string> stages = new List<string>()
                {
                    "parRaceTime1" ,
                    "parRaceTime2" ,
                    "parRaceTime3" ,
                    "parRaceTime4" ,
                    "parRaceTime5" ,
                    "parRaceTime6" ,
                    "parRaceTime7" ,
                    "parRaceTime8"
                };

                foreach (string stage in stages)
                {
                    int stageWinnerTime = pointsManager.GetStageAndAgeGroupWinnerTime(stage, ageGroup);
                    List<ParticipantsData> participants = new List<ParticipantsData>();
                    participants = pointsManager.SelectParticipantsByAgeGroupForPointUpload(stage, ageGroup);

                    foreach (var participant in participants)
                    {
                        int parStageTime = pointsManager.GetParStageTime(participant.Id, stage);
                        double points = Convert.ToDouble(stageWinnerTime) / Convert.ToDouble(parStageTime) * 1000;
                        int pointsToUpload = Convert.ToInt32(points);

                        string stagePointSlot = pointsManager.GetStagePointSlot(stage);

                        string query = "UPDATE Participants SET "+ stagePointSlot +" = @p1 WHERE id = @p2";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.Add("@p1", SqlDbType.Int).Value = pointsToUpload;
                        cmd.Parameters.Add("@p2", SqlDbType.Int).Value = participant.Id;
                        //cmd.Parameters.Add("@p3", SqlDbType.VarChar).Value = stagePointSlot;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public string GetStagePointSlot(string stage)
        {
            string stagePointSlot = "parPoints1";
            if (stage == "parRaceTime2") { stagePointSlot = "parPoints2"; }
            if (stage == "parRaceTime3") { stagePointSlot = "parPoints3"; }
            if (stage == "parRaceTime4") { stagePointSlot = "parPoints4"; }
            if (stage == "parRaceTime5") { stagePointSlot = "parPoints5"; }
            if (stage == "parRaceTime6") { stagePointSlot = "parPoints6"; }
            if (stage == "parRaceTime7") { stagePointSlot = "parPoints7"; }
            if (stage == "parRaceTime8") { stagePointSlot = "parPoints8"; }

            return stagePointSlot;
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

        public int GetStageAndAgeGroupWinnerTime(string stage, string parAgeGroup)
        {
            int groupWinnerTime = 0;
            string query = "SELECT * FROM Participants WHERE parAgeGroup = @p1 ORDER BY " + stage;
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@p1", SqlDbType.VarChar).Value = parAgeGroup;

            reader = cmd.ExecuteReader();
            reader.Read();

            groupWinnerTime = Convert.ToInt32(reader[stage]);

            reader.Close();
            return groupWinnerTime;
        }

        public List<ParticipantsData> SelectParticipantsByAgeGroupForPointUpload(string stage, string parAgeGroup)
        {
            cmd = new SqlCommand("SELECT * FROM Participants WHERE parAgeGroup = @p1", conn);
            cmd.Parameters.Add("@p1", SqlDbType.VarChar).Value = parAgeGroup;
            reader = cmd.ExecuteReader();

            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parRaceTime1 = Convert.ToInt32(reader[stage]);
                result.Add(data);
            }

            reader.Close();

            return result;
        }

        public int GetParStageTime(int Id, string stage)
        {
            int parStageTime = 0;

            cmd = new SqlCommand("SELECT * FROM Participants WHERE Id = @p2", conn);

            //cmd.Parameters.Add("@p1", SqlDbType.VarChar).Value = stage;
            cmd.Parameters.Add("@p2", SqlDbType.VarChar).Value = Id;

            reader = cmd.ExecuteReader();
            reader.Read();

            parStageTime = Convert.ToInt32(reader[stage]);

            reader.Close();

            return parStageTime;
        }
    }
}
