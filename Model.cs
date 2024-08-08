namespace maincs.Models
{
    public class Employees
    {
        public const int TotalHours = 176;
        public const decimal OverTimeRate = 1.25m;
        protected int id;
        protected string name;
        protected decimal LoggedHours;
        protected decimal Wage;

        protected Employees(int id, string name, decimal loggedHours, decimal wage)
        {
            this.id = id;
            this.name = name;
            LoggedHours = loggedHours;
            Wage = wage;
        }
        private decimal BasicSalary()
        {
            return Wage * LoggedHours;
        }
        private decimal OverTimeSalary()
        {
            var val = Max(0, LoggedHours - TotalHours);
            return (val * Wage * OverTimeRate);
        }

        public virtual decimal Calaulate()
        {
            return BasicSalary() + OverTimeSalary();
        }

        public override string ToString()
        {
            return $"{GetType().ToString().Replace("maincs.Models.", "")}" +
                    $"\nId : {id}" +
                    $"\nName : {name}" +
                    $"\nLogged Hours : {LoggedHours}" +
                    $"\nWage : {Round(Wage, 2):N0}" +
                    $"\nBasic Salary : ${Round(BasicSalary(), 3):N0}" +
                    $"\nOvertime Salary : ${Round(OverTimeSalary(), 3):N0}";
        }

    }
    public class Managers : Employees
    {
        public const decimal Allowance = 0.05m;
        public Managers(int id, string name, decimal loggedHours, decimal wage) : base(id, name, loggedHours, wage) { }
        private decimal CalaculateAllowance()
        {
            return Allowance * base.Calaulate();
        }
        public override decimal Calaulate()
        {
            return base.Calaulate() + CalaculateAllowance();
        }
        public override string ToString()
        {
            return base.ToString() +
                  $"\nAllowance: ${Round(CalaculateAllowance(), 3):N0}" +
                  $"\nTotal Salary: ${Round(this.Calaulate(), 3):N0}";
        }
    }

    public class Maintanence : Employees
    {
        public const decimal HardShip = 100m;
        public Maintanence(int id, string name, decimal loggedHours, decimal wage) : base(id, name, loggedHours, wage) { }
        public override decimal Calaulate()
        {
            return base.Calaulate() + HardShip;
        }
        public override string ToString()
        {
            return base.ToString() +
                  $"\nHardShip: ${Round(HardShip, 3):N0}" +
                  $"\nTotal Salary: ${Round(this.Calaulate(), 3):N0}";
        }
    }

    public class Sales : Employees
    {
        private decimal SalesVolume;
        private decimal Commission;
        public Sales(int id, string name, decimal loggedHours, decimal wage, decimal SalesVolume, decimal Commission) : base(id, name, loggedHours, wage)
        { 
            this.SalesVolume = SalesVolume;
            this.Commission = Commission;
        }
        private decimal CalaculateBonus()
        {
            return SalesVolume * Commission;
        }
        public override decimal Calaulate()
        {
            return base.Calaulate() + CalaculateBonus();
        }
        public override string ToString()
        {
            return base.ToString() +
                  $"\nBonus: ${Round(CalaculateBonus(), 3):N0}" +
                  $"\nTotal Salary: ${Round(this.Calaulate(), 3):N0}";
        }
    }

    public class Developer : Employees
    {
        private bool TaskCompleted;
        public const decimal Commission = 0.03m;
        public Developer(int id, string name, decimal loggedHours, decimal wage, bool TaskCompleted) : base(id, name, loggedHours, wage)
        {
            this.TaskCompleted = TaskCompleted;
        }
        private decimal CalaculateBonus()
        {
            return (TaskCompleted ? base.Calaulate() * Commission : 0);
        }
        public override decimal Calaulate()
        {
            return base.Calaulate() + CalaculateBonus();
        }
        public override string ToString()
        {
            return base.ToString() +
                  $"\nTaskCompleted: {(TaskCompleted ? "YES" : "NO")}" +
                  $"\nBonus: ${Round(CalaculateBonus(), 3):N0}" +
                  $"\nTotal Salary: ${Round(this.Calaulate(), 3):N0}";
        }
    }
}
