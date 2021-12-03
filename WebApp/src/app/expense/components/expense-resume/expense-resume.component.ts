import { Component, OnInit } from "@angular/core";

@Component({
  selector: "cf-expense-resume",
  templateUrl: "./expense-resume.component.html",
  styleUrls: ["./expense-resume.component.css"],
})
export class ExpenseResumeComponent implements OnInit {
  total: number = 15000;
  totalReal: number = 8000;
  constructor() {}

  ngOnInit(): void {}
}
