import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Input,
} from "@angular/core";
import { Involved } from "../interfaces/involved";

@Component({
  selector: "cf-involved-in-the-expense",
  templateUrl: "./involved-in-the-expense.component.html",
  styleUrls: ["./involved-in-the-expense.component.css"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class InvolvedInTheExpenseComponent implements OnInit {
  @Input() involveds: Involved[] = [
    {
      name: "Lucas Silvério",
      picture: "assets/lucas.jpg",
      owner: true,
      value: 100,
    },
    {
      name: "Samara Danelon",
      picture: "assets/samara.jpg",
      owner: false,
      value: 100,
    },
  ];

  users: { name: string; picture: string }[] = [
    { name: "Lucas Silvério", picture: "assets/lucas.jpg" },
    {
      name: "Samara Danelon",
      picture: "assets/samara.jpg",
    },
  ];
  showDetail = false;
  showAddInvolved = false;
  @Input() total: number = 200;
  constructor() {}

  ngOnInit(): void {}

  matchValue() {
    return (
      this.involveds.reduce((x, y) => {
        return x + y.value;
      }, 0) != this.total
    );
  }

  deleteInvolved(involved: Involved) {
    const index = this.involveds.indexOf(involved);
    this.involveds.splice(index, 1);
  }

  addUser(user:any){
    let newInvolved={} as Involved;
    Object.assign(newInvolved,user);
    newInvolved.owner = false;
    newInvolved.value = 0;

    this.involveds.push(newInvolved);
    this.showAddInvolved = false;
  }
}
