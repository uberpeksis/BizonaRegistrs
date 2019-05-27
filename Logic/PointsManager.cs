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
            AgeGroupManager ageGroupManager = new AgeGroupManager();
            
            List<string> ageGroupList = new List<string>();
            ageGroupList = ageGroupManager.GetAgeGroupList();

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

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            pointsManager.UpdateParSumPoints();

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

            cmd = new SqlCommand("SELECT * FROM Participants WHERE Id = @p1", conn);

            cmd.Parameters.Add("@p1", SqlDbType.VarChar).Value = Id;

            reader = cmd.ExecuteReader();
            reader.Read();

            parStageTime = Convert.ToInt32(reader[stage]);

            reader.Close();

            return parStageTime;
        }

        public void UpdateParSumPoints()
        {
            ResultsManager resultsManager = new ResultsManager();
            List<ParticipantsData> participants = new List<ParticipantsData>();
            participants = resultsManager.SelectAllParticipants();

            foreach (var participant in participants)
            {
                int pointSumToUpload = participant.parPoints1 +
                                       participant.parPoints2 +
                                       participant.parPoints3 +
                                       participant.parPoints4 +
                                       participant.parPoints5 +
                                       participant.parPoints6 +
                                       participant.parPoints7 +
                                       participant.parPoints8;

                cmd = new SqlCommand("UPDATE Participants SET parPointsSum = @p1 WHERE id = @p2", conn);
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = pointSumToUpload;
                cmd.Parameters.Add("@p2", SqlDbType.Int).Value = participant.Id;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
