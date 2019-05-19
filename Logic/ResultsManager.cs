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
            cmd = new SqlCommand("SELECT * FROM Participants", conn);
            reader = cmd.ExecuteReader();

            List<ParticipantsData> result = new List<ParticipantsData>();
            while (reader.Read())
            {
                ParticipantsData data = new ParticipantsData();
                data.Id = Convert.ToInt32(reader["Id"]);
                data.parName = Convert.ToString(reader["parName"]);
                data.parSurname = Convert.ToString(reader["parSurname"]);
                data.parNumber = Convert.ToInt32(reader["parNumber"]);
                data.parAgeGroup = Convert.ToInt32(reader["parAgeGroup"]);
                data.parRaceTime = Convert.ToInt32(reader["parRaceTime"]);
                data.parPoints = Convert.ToInt32(reader["parPoints"]);
                result.Add(data);
            }

            reader.Close();

            return result;
        }
    }
}
