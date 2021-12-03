import { Component, OnInit } from "@angular/core";

@Component({
  selector: "cf-expense-resume",
  templateUrl: "./expense-resume.component.html",
  styleUrls: ["./expense-resume.component.css"],
})
export class ExpenseResumeComponent implements OnInit {
  total: number = 15000;
  totalReal: number = 8000;
  reimbursement:number = 1000;
  categories=[
    {
      color:'#850991',
      description:'Educação',
      value: 100,
      icon: 'school'
    },
    {
      color:'#609441',
      description:'Moradia',
      value: 300,
      icon: 'home'
    },
    {
      color:'#f1648e',
      description:'Carro',
      value: 900,
      icon: 'directions_car'
    }
  ]
  constructor() {}

  ngOnInit(): void {}
}
