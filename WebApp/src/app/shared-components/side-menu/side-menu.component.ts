import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";

@Component({
  selector: "cf-side-menu",
  templateUrl: "./side-menu.component.html",
  styleUrls: ["./side-menu.component.css"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SideMenuComponent implements OnInit {
  public open = true;
  constructor() {}

  ngOnInit(): void {}
}
