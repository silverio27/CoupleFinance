import { Component, OnInit, ViewChild } from "@angular/core";

import { CategoryEditComponent } from "../../components/category-component/category-edit.component";
import { Category } from "../../interfaces/category";


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
