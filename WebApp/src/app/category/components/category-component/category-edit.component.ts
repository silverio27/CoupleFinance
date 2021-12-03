import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Output,
  EventEmitter,
} from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { map, startWith } from "rxjs/operators";
import { ICategoryPresents } from "src/app/shared-components/interfaces/icategory-presents";
import { IconService } from "../../icon.service";
import { Category, NewCategory } from "../../interfaces/category";


@Component({
  selector: "cf-category-edit",
  templateUrl: "./category-edit.component.html",
  styleUrls: ["./category-edit.component.css"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CategoryEditComponent implements OnInit {
  @Output() close = new EventEmitter();
  @Output() save = new EventEmitter<Category>();
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
  editCategory = {} as NewCategory;
  id: number = 0;
  constructor(public iconService: IconService) {}

  ngOnInit(): void {
    this.filteredOptions = this.iconControl.valueChanges.pipe(
      startWith(""),
      map((value) => this.iconService.get(value))
    );
  }

  initializeCategoryToEdit(category: Category, id: number) {
    this.id = id;
    Object.assign(this.editCategory, category);
  }

  updatePreview() {
    this.preview = {
      backgroundColor: this.editCategory.color,
      categoryName: this.editCategory.description,
      icon: this.editCategory.icon,
      color: "white",
      description: "Exemplo",
    };
  }

  add() {
    let category = {} as Category;
    Object.assign(category, this.editCategory);
    this.save.emit(category);
    this.close.emit();
  }
}
