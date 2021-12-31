import { Component, OnInit, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";

export interface User {
  id: string;
  name: string;
  email: string;
  active: boolean;
}

@Component({
  templateUrl: "./users.component.html",
  styleUrls: ["./users.component.css"],
})
export class UsersComponent implements OnInit {
  displayedColumns: string[] = ["name", "email", "active", "actions"];
  dataSource!: MatTableDataSource<User>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor() {
    const users: User[] = [
      {
        id: "333",
        name: "Lucas Silvério",
        email: "silveiro.des.vargas@gmail.com",
        active: false,
      },
    ];
    this.dataSource = new MatTableDataSource(users);
  }

  ngOnInit(): void {}
}
