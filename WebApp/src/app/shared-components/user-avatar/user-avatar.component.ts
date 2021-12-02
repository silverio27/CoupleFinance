import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Input,
  Output,
  EventEmitter,
} from "@angular/core";

@Component({
  selector: "cf-user-avatar",
  templateUrl: "./user-avatar.component.html",
  styleUrls: ["./user-avatar.component.css"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserAvatarComponent implements OnInit {
  @Input() showName: boolean = true;
  @Input() pic: string = "assets/lucas.jpg";
  @Input() name: string = "Lucas Silvério";
  @Output() clickAvatar = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}
}
