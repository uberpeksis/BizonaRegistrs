using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AgeGroupManager
    {
        public string GetParAgeGroup(int parBirthYear, string parGender)
        {
            string parAgeGroup = "Nav pareizi norādīts dzimums vai dzimšanas gards!";

            if (parGender == "Male")
            {
                if (parBirthYear >= 2013) { parAgeGroup = "Par jaunu!"; }
                if (parBirthYear >= 2010 && parBirthYear <= 2012) { parAgeGroup = "V 3"; }
                if (parBirthYear >= 2008 && parBirthYear <= 2009) { parAgeGroup = "V 5"; }
                if (parBirthYear >= 2006 && parBirthYear <= 2007) { parAgeGroup = "V 7"; }
                if (parBirthYear >= 2004 && parBirthYear <= 2005) { parAgeGroup = "V 9"; }
                if (parBirthYear == 2003) { parAgeGroup = "V 10"; }
                if (parBirthYear >= 2001 && parBirthYear <= 2002) { parAgeGroup = "V 12"; }
                if (parBirthYear >= 1999 && parBirthYear <= 2000) { parAgeGroup = "V 14"; }
                if (parBirthYear >= 1997 && parBirthYear <= 1998) { parAgeGroup = "V 16"; }
                if (parBirthYear >= 1995 && parBirthYear <= 1996) { parAgeGroup = "V 18"; }
                if (parBirthYear >= 1993 && parBirthYear <= 1994) { parAgeGroup = "V 20"; }
                if (parBirthYear >= 1979 && parBirthYear <= 1992) { parAgeGroup = "V 21"; }
                if (parBirthYear >= 1974 && parBirthYear <= 1978) { parAgeGroup = "V 35"; }
                if (parBirthYear >= 1969 && parBirthYear <= 1973) { parAgeGroup = "V 40"; }
                if (parBirthYear >= 1964 && parBirthYear <= 1968) { parAgeGroup = "V 45"; }
                if (parBirthYear >= 1959 && parBirthYear <= 1963) { parAgeGroup = "V 50"; }
                if (parBirthYear >= 1954 && parBirthYear <= 1958) { parAgeGroup = "V 55"; }
                if (parBirthYear >= 1949 && parBirthYear <= 1953) { parAgeGroup = "V 60"; }
                if (parBirthYear >= 1944 && parBirthYear <= 1948) { parAgeGroup = "V 65"; }
                if (parBirthYear >= 1939 && parBirthYear <= 1943) { parAgeGroup = "V 70"; }
                if (parBirthYear >= 1934 && parBirthYear <= 1938) { parAgeGroup = "V 75"; }
                if (parBirthYear <= 1933) { parAgeGroup = "V 80"; }
            }
            else if (parGender == "Female")
            {
                if (parBirthYear >= 2013) { parAgeGroup = "Par jaunu!"; }
                if (parBirthYear >= 2010 && parBirthYear <= 2012) { parAgeGroup = "S 3"; }
                if (parBirthYear >= 2008 && parBirthYear <= 2009) { parAgeGroup = "S 5"; }
                if (parBirthYear >= 2006 && parBirthYear <= 2007) { parAgeGroup = "S 7"; }
                if (parBirthYear >= 2004 && parBirthYear <= 2005) { parAgeGroup = "S 9"; }
                if (parBirthYear == 2003) { parAgeGroup = "S 10"; }
                if (parBirthYear >= 2001 && parBirthYear <= 2002) { parAgeGroup = "S 12"; }
                if (parBirthYear >= 1999 && parBirthYear <= 2000) { parAgeGroup = "S 14"; }
                if (parBirthYear >= 1997 && parBirthYear <= 1998) { parAgeGroup = "S 16"; }
                if (parBirthYear >= 1995 && parBirthYear <= 1996) { parAgeGroup = "S 18"; }
                if (parBirthYear >= 1993 && parBirthYear <= 1994) { parAgeGroup = "S 20"; }
                if (parBirthYear >= 1979 && parBirthYear <= 1992) { parAgeGroup = "S 21"; }
                if (parBirthYear >= 1974 && parBirthYear <= 1978) { parAgeGroup = "S 35"; }
                if (parBirthYear >= 1969 && parBirthYear <= 1973) { parAgeGroup = "S 40"; }
                if (parBirthYear >= 1964 && parBirthYear <= 1968) { parAgeGroup = "S 45"; }
                if (parBirthYear >= 1959 && parBirthYear <= 1963) { parAgeGroup = "S 50"; }
                if (parBirthYear >= 1954 && parBirthYear <= 1958) { parAgeGroup = "S 55"; }
                if (parBirthYear >= 1949 && parBirthYear <= 1953) { parAgeGroup = "S 60"; }
                if (parBirthYear >= 1944 && parBirthYear <= 1948) { parAgeGroup = "S 65"; }
                if (parBirthYear >= 1939 && parBirthYear <= 1943) { parAgeGroup = "S 70"; }
                if (parBirthYear >= 1934 && parBirthYear <= 1938) { parAgeGroup = "S 75"; }
                if (parBirthYear <= 1933) { parAgeGroup = "S 80"; }
            }
            return parAgeGroup;
        }
    }
}
