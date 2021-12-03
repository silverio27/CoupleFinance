import { Component, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { IconService } from "./icon.service";
import { map, startWith } from "rxjs/operators";
import { ICategoryPresents } from "../shared-components/interfaces/icategory-presents";

export interface Category {
  id: number;
  color: string;
  description: string;
  icon: string;
}
export interface NewCategory {
  color: string;
  description: string;
  icon: string;
}
@Component({
  selector: "cf-category",
  templateUrl: "./category.component.html",
  styleUrls: ["./category.component.css"],
})
export class CategoryComponent implements OnInit {
  showAddCategory = false;
  colors: string[] = [
    "#850991",
    "#609441",
    "#f1648e",
    "#31b4c6",
    "#fee13b",
    "#fcb468",
  ];
  iconControl = new FormControl();
  filteredOptions!: Observable<string[]>;
  preview = {} as ICategoryPresents;
  newCategory = {} as NewCategory;
  categories: Category[] = [
    {
      color: "#850991",
      description: "Educação",
      icon: "school",
      id: 1,
    },
  ];
  constructor(public iconService: IconService) {}

  ngOnInit(): void {
    this.filteredOptions = this.iconControl.valueChanges.pipe(
      startWith(""),
      map((value) => this.iconService.get(value))
    );
  }

  updatePreview() {
    this.preview = {
      backgroundColor: this.newCategory.color,
      categoryName: this.newCategory.description,
      icon: this.newCategory.icon,
      color: "white",
      description: "Exemplo",
    };
  }

  save() {
    let categorie={}as Category;
    Object.assign(categorie, this.newCategory);
    this.categories.push(categorie);
    this.showAddCategory = false;
  }
}
