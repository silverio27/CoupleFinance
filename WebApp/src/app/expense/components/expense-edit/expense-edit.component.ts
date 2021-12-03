import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Output,
  EventEmitter,
} from "@angular/core";
import { Category } from "src/app/category/interfaces/category";
import { Expense } from "../../expense";

@Component({
  selector: "cf-expense-edit",
  templateUrl: "./expense-edit.component.html",
  styleUrls: ["./expense-edit.component.css"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExpenseEditComponent implements OnInit {
  @Output() close = new EventEmitter();
  @Output() save = new EventEmitter<Expense>();
  category = {} as Category;
  categories: Category[] = [
    {
      color: "#850991",
      description: "Educação",
      icon: "school",
      id: 1,
    },
  ];
  description: string = "";
  periodoId: number = 202112;
  value: number = 0;
  banks:string[]=["Nubank"];
  bank:string ='';

  expense={}as Expense;
  constructor() {}

  ngOnInit(): void {}

  displayFn(category: Category): string {
    return category && category.description ? category.description : "";
  }

  add(){
    this.save.emit(this.expense);
    this.close.emit();
  }
}
