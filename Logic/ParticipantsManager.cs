using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ParticipantsManager : BaseManeger
    {
        public void CreateNewParticipant(string parName, string parSurname, int parNumber, string parBirthYear, int parRaceTime)
        {
            cmd = new SqlCommand("INSERT INTO Participants(parName, parSurname, parNumber, parAgeGroup, parRaceTime, parPoints) VALUES(@p1, @p2, @p3, @p4, @p5, @p6)", conn);

            cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = parName;
            cmd.Parameters.Add("@p2", SqlDbType.NVarChar).Value = parSurname;
            cmd.Parameters.Add("@p3", SqlDbType.Int).Value = parNumber;
            cmd.Parameters.Add("@p4", SqlDbType.VarChar).Value = parBirthYear;
            cmd.Parameters.Add("@p5", SqlDbType.Int).Value = parRaceTime;
            cmd.Parameters.Add("@p6", SqlDbType.Int).Value = 1;

            cmd.ExecuteNonQuery();
        }
    }
}
