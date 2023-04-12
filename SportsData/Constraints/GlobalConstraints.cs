namespace SportsData.Constraints
{
    public class GlobalConstraints
    {
        public const int CoachNameMax = 30;
        public const int CoachNameMin = 2;

        public const int CoachAgeMin = 18;
        public const int CoachAgeMax = 80;

        public const int TeamNameMax = 50;

        public const int StadiumNameMax = 50;

        public const int StadiumCapacityMax = 200000;

        public const string connect = "Server=.;Database=SportsData;Trusted_Connection=True; trustServerCertificate=true";


    }
}
