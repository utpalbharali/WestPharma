using Rupils.CommandHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WestPharma.Models;

namespace WestPharma.ViewModels
{
    public class VM_Employee : INotifyPropertyChanged
    {
        DBSqlite dBSqlite = null;
        public List<Employee> _listOfEmployees { get; set; }
        public VM_Employee()
        {
            dBSqlite = DBSqlite.SqliteObjCheck();
            //_listOfEmployees = Employeees().Result;
            //if (_listOfEmployees.Count == 0)
            //{
            //    InsertEmployee();
            //}
        }

        private ICommand _BtnLoadEmp;
        public ICommand BtnLoadEmp
        {
            get
            {
                return _BtnLoadEmp ?? (_BtnLoadEmp = new CommandHandler(() => Action_BtnLoadEmp(), () => CanExecute()));
            }
        }

        private bool CanExecute()
        {
            return true;
        }

        private int _DetailsByEmpId;

        public int DetailsByEmpId
        {
            get { return _DetailsByEmpId; }
            set { _DetailsByEmpId = value; }
        }

        private async void Action_BtnLoadEmp()
        {
            LoadEmployee(DetailsByEmpId);
        }

        public async Task<List<Employee>> Employeees()
        {
            return await GetEmployees();
        }

        private async Task<int> InsertEmployee()
        {
            Employee emp = new();

            emp.OfficeEmail = "utpal@westpharma.com";
            emp.DeptId = 2;
            emp.ReportingManager = "David";
            emp.ProfileId = 2;
            emp.EmpCode = "EMP005";
            emp.EmpId = 5;
            emp.ProfileId = 5;

            return await dBSqlite.InsertIntoSql(emp);
        }

        Dictionary<int, Profile> empIdToEmployee = new();
        Dictionary<int, Dept> deptIdToDepartment = new();
        private void LoadEmployee(int empid)
        {
            var _emp = _listOfEmployees.Where(a => a.EmpId == empid).FirstOrDefault();
            if (empIdToEmployee.ContainsKey(_emp.ProfileId))
                Name = empIdToEmployee[_emp.ProfileId].Name;
            if (deptIdToDepartment.ContainsKey(_emp.DeptId))
                Dept = deptIdToDepartment[_emp.ProfileId].DeptName;

            Designation = _emp.Designation;
            Phone = _emp.ProfileId;
            Email = _emp.OfficeEmail;
            OfficeEmail = _emp.OfficeEmail;
            ReportingManager = _emp.ReportingManager;
            EmpCode = _emp.EmpCode;
            if (empIdToEmployee.ContainsKey(_emp.ProfileId))
            PAN = empIdToEmployee[_emp.ProfileId].PAN;
            if (empIdToEmployee.ContainsKey(_emp.ProfileId))
                Address = empIdToEmployee[_emp.ProfileId].Address;
            if (empIdToEmployee.ContainsKey(_emp.ProfileId))
                AdhaarNo = empIdToEmployee[_emp.ProfileId].AdhaarNo;
        }

        private async Task<List<Employee>> GetEmployees()
        {
            return await dBSqlite.GetAllEmployees();
        }


        //properties
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(nameof(Name)); }
        }

        private Int64 _Phone;

        public Int64 Phone
        {
            get { return _Phone; }
            set { _Phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(nameof(Email)); }
        }

        private string _PAN;

        public string PAN
        {
            get { return _PAN; }
            set { _PAN = value; OnPropertyChanged(nameof(PAN)); }
        }

        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; OnPropertyChanged(nameof(Address)); }
        }


        private Int64 _AdhaarNo;

        public Int64 AdhaarNo
        {
            get { return _AdhaarNo; }
            set { _AdhaarNo = value; OnPropertyChanged(nameof(AdhaarNo)); }
        }


        // Official Details Porperties
        private string _Dept;

        public string Dept
        {
            get { return _Dept; }
            set { _Dept = value; OnPropertyChanged(nameof(Dept)); }
        }

        private string _Designation;

        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; OnPropertyChanged(nameof(Designation)); }
        }

        private string _ReportingManager;

        public string ReportingManager
        {
            get { return _ReportingManager; }
            set { _ReportingManager = value; OnPropertyChanged(nameof(ReportingManager)); }
        }

        private string _EmpCode;

        public string EmpCode
        {
            get { return _EmpCode; }
            set { _EmpCode = value; OnPropertyChanged(nameof(EmpCode)); }
        }

        private string _OfficeEmail;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string OfficeEmail
        {
            get { return _OfficeEmail; }
            set { _OfficeEmail = value; OnPropertyChanged(nameof(OfficeEmail)); }
        }



    }
}
