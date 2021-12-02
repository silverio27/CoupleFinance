import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Input,
} from "@angular/core";
import { ICategoryPresents } from "../interfaces/icategory-presents";

@Component({
  selector: "cf-category-presents",
  templateUrl: "./category-presents.component.html",
  styleUrls: ["./category-presents.component.css"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CategoryPresentsComponent implements OnInit {
  @Input() value: ICategoryPresents = {
    backgroundColor : "#850991",
    color: "white",
    categoryName: "Categoria",
    description:"Descrição",
    icon: 'school'
  }
  constructor() {}

  ngOnInit(): void {}
}
