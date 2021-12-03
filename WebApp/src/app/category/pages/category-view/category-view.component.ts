import { Component, OnInit, ViewChild } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";

import { delay, map, startWith } from "rxjs/operators";
import { ICategoryPresents } from "src/app/shared-components/interfaces/icategory-presents";
import { CategoryEditComponent } from "../../components/category-component/category-editt.component";
import { IconService } from "../../icon.service";

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
  templateUrl: "./category-view.component.html",
  styleUrls: ["./category-view.component.css"],
})
export class CategoryViewComponent implements OnInit {
  @ViewChild(CategoryEditComponent) categoryEdit!: CategoryEditComponent;
  showAddCategory = false;

  categories: Category[] = [
    {
      color: "#850991",
      description: "Educação",
      icon: "school",
      id: 1,
    },
  ];
  constructor() {}

  ngOnInit(): void {}

  add(category: Category) {
    if (category.id == undefined) this.categories.push(category);
  }

  remove(category: Category) {
    const index = this.categories.indexOf(category);
    this.categories.splice(index, 1);
  }

  edit(category: Category) {
    this.showAddCategory = true;
    setTimeout(() => {
      this.categoryEdit.initializeCategoryToEdit(category, category.id);
    }, 500);
  }
}
