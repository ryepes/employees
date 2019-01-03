import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  public employees: Employees[];
  employeeId = '';
  public oneEmployee;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Employees[]>(baseUrl + 'api/Employee/GetEmployees').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }

  getEmployee() {
    this.http.get('https://localhost:44396/api/Employee/GetEmployeeById?id=' + this.employeeId).subscribe(result => {
      this.oneEmployee = result;
    }, error => console.error(error));
  }

}

interface Employees {
  id: number;
  name: number;
  contractTypeName: string;
  roleId: number;
  roleName: string;
  roleDescription: string;
  hourlySalary: number;
  monthlySalary: number;
}
