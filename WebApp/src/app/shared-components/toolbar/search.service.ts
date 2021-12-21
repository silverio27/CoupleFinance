import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";


@Injectable({
  providedIn: "root",
})
export class SearchService {
  public value = new BehaviorSubject<string>("");

  constructor() {}
}
