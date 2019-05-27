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
        public void CreateNewParticipant(string parName, string parSurname, int parNumber, string parBirthYear, int parRaceTime1, int parRaceTime2, int parRaceTime3, int parRaceTime4, int parRaceTime5, int parRaceTime6, int parRaceTime7, int parRaceTime8)
        {
            cmd = new SqlCommand("INSERT INTO Participants(parName, parSurname, parNumber, parAgeGroup, parRaceTime1, parRaceTime2, parRaceTime3, parRaceTime4, parRaceTime5, parRaceTime6, parRaceTime7, parRaceTime8, parPoints1, parPoints2, parPoints3, parPoints4, parPoints5, parPoints6, parPoints7, parPoints8, parPointsSum) VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20, @p21)", conn);

            if (parRaceTime1 == 0) { parRaceTime1 = 999999999; }
            if (parRaceTime2 == 0) { parRaceTime2 = 999999999; }
            if (parRaceTime3 == 0) { parRaceTime3 = 999999999; }
            if (parRaceTime4 == 0) { parRaceTime4 = 999999999; }
            if (parRaceTime5 == 0) { parRaceTime5 = 999999999; }
            if (parRaceTime6 == 0) { parRaceTime6 = 999999999; }
            if (parRaceTime7 == 0) { parRaceTime7 = 999999999; }
            if (parRaceTime8 == 0) { parRaceTime8 = 999999999; }

            cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = parName;
            cmd.Parameters.Add("@p2", SqlDbType.NVarChar).Value = parSurname;
            cmd.Parameters.Add("@p3", SqlDbType.Int).Value = parNumber;
            cmd.Parameters.Add("@p4", SqlDbType.VarChar).Value = parBirthYear;
            cmd.Parameters.Add("@p5", SqlDbType.Int).Value = parRaceTime1;
            cmd.Parameters.Add("@p6", SqlDbType.Int).Value = parRaceTime2;
            cmd.Parameters.Add("@p7", SqlDbType.Int).Value = parRaceTime3;
            cmd.Parameters.Add("@p8", SqlDbType.Int).Value = parRaceTime4;
            cmd.Parameters.Add("@p9", SqlDbType.Int).Value = parRaceTime5;
            cmd.Parameters.Add("@p10", SqlDbType.Int).Value = parRaceTime6;
            cmd.Parameters.Add("@p11", SqlDbType.Int).Value = parRaceTime7;
            cmd.Parameters.Add("@p12", SqlDbType.Int).Value = parRaceTime8;
            cmd.Parameters.Add("@p13", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p14", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p15", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p16", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p17", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p18", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p19", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p20", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@p21", SqlDbType.Int).Value = 0;

            cmd.ExecuteNonQuery();
        }
    }
}
