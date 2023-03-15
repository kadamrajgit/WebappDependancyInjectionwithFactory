namespace WebappDependancyInjection
{
    public interface IStudents
    {
        public string getStudentCount();
    }

    public class MathStudent : IStudents
    {
        public string getStudentCount()
        {
            return "Maths";
        }
    }

    public class PhysicsStudent : IStudents
    {
        public string getStudentCount()
        {
            return "Physics";
        }
    }


    public class GetClassFactory
    {
        private readonly IServiceProvider serviceProvider;

        public GetClassFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IStudents GetClassDeatils(string subject)
        {
            if (subject == "Math")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return (IStudents)serviceProvider.GetService(typeof(MathStudent));
#pragma warning restore CS8603 // Possible null reference return.
            }
            else
            {
#pragma warning disable CS8603 // Possible null reference return.
                return (IStudents)serviceProvider.GetService(typeof(PhysicsStudent));
#pragma warning restore CS8603 // Possible null reference return.
            }
            
                          
        }

    }
}
