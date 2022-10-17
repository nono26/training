using Microsoft.EntityFrameworkCore;

namespace Nasa.Web.Model
{
    public class SpaceShuttle : IDisposable
    {
        //According to me, _id cannot be null, it is a primary key on database
        private long _id { get; set; } //see with business team or database team why it is a long type
        private string _color { get; set; } 
        public AssemblyLine Type { get; set; }
        private long _mileage { get; set; } //see with business team or database team why it is long type and 
        private int _oilLevel {get;set;} //see with business team or database team why it is an it type
        private const int MinOilLevelForStarting = 20;

        //dependency with Data layer. Better to put it outside of the spaceShuttle class (and init it on the startup.cs file with a serviceProvider for instance )
        //I decided to init it on the constructor because it is a code review, not a design session, so I make it works.
        private readonly Nasa.Data.AppDbContext _dbContext;        

        public SpaceShuttle (){
            var contextOptions = new DbContextOptionsBuilder<Nasa.Data.AppDbContext>()
                .UseSqlServer(@"MyConnectionString")
                .Options;

                _dbContext= new Nasa.Data.AppDbContext(contextOptions);
                //Because dbContext has been initilized inside the constructor, SpaceShuttle class must be Disposable to release the dbContext.
        }
        
        public SpaceShuttle(long id, string color, AssemblyLine type):base()
        {
            this._id = id;
            this._color = color;
            this.Type = type;
        }

        public SpaceShuttle(long id, string color, AssemblyLine type, long mileage, int oilLevel) : this(id, color, type){
            if(oilLevel>0) //simple validation, see with business of data team for more complex one
                this._oilLevel= oilLevel;
            if(mileage>0) 
                this._mileage= mileage;
        }

        public async Task Save()
        {   
            await this._dbContext.SaveChangesAsync();            
        }
        
        public async Task<SpaceShuttle> Get(long id)
        {
            return await this._dbContext.SpaceShuttles.SingleAsync(s=> s._id== id);
        }

        public string GetModel()
        {  
            return $"This shuttle is a {this.Type}"; //Can it return only the type? 
        }
        
        public async Task<SpaceShuttle> GetShuttleAndUpdateMileage()
        {
            this._mileage = _mileage++;
            await this.Save();
            return this;//Why? business requirement?
        }

        public bool Start()
        {
            return this._oilLevel>MinOilLevelForStarting;
        }

        public void Dispose(){
            _dbContext.Dispose();
        }

        private void LogUnsufficientOil(){
            Console.WriteLine("Insufficient oil");//See with business team for better uses of logs
        }       
    }
}

//New file:
namespace Nasa.Web
{  
    public enum AssemblyLine
    {
        Enterprise,
        Columbia1,
        Columbia2,//Why Columbia2 ?
        Challenger,
        Discovery,
        Atlantis
    }
}

//New file :
namespace Nasa.Web{

    public static class AssemblyLineFactory
    {
            public static int GetNumberOfPassengers(AssemblyLine type)
            {
                //what about the other AssemblyLine?
                var numberOfPassenger= 0;
                switch(type){
                    case AssemblyLine.Enterprise:
                    case AssemblyLine.Challenger:
                        numberOfPassenger=4;
                        break;
                    case AssemblyLine.Atlantis:
                        numberOfPassenger= 5;
                        break;
                }
                return numberOfPassenger;
            }
            
            public static bool HasSolarPanel(AssemblyLine type)
            {
                var hasSolarPanel= false;

                var shuttleWithSolarPanel = new Enum[]{ 
                    AssemblyLine.Enterprise,
                    AssemblyLine.Columbia1,
                    AssemblyLine.Columbia2,
                    AssemblyLine.Challenger,
                    AssemblyLine.Atlantis
                };
   
                foreach(AssemblyLine shuttle in shuttleWithSolarPanel){
                    if(shuttle== type)
                        hasSolarPanel=true;
                        break;
                }              
                return hasSolarPanel;
            }
        }
}

//We can imagine to add 2 new properties to Space Shuttle class : _NumberOfPassengers and _hasSolarPanel
//to go further we can imagine as well to initiliaze the space shuttle through a factory pattern. assemblyLine may not be anymore an enum type but several classes

//new file
namespace Nasa.Data
{
    public class AppDbContext: DbContext{ 
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

        public DbSet<Nasa.Web.Model.SpaceShuttle>  SpaceShuttles=> Set<Nasa.Web.Model.SpaceShuttle>();
    
    }
}

/*
Extract to of the startup.cs file. It is how I would prefer init the dbContext
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("myConnectionString")));
}
*/
