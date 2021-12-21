import { Component, OnInit } from '@angular/core';
import { SearchService } from 'src/app/shared-components/toolbar/search.service';

@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.css']
})
export class ExpenseComponent implements OnInit {

  showEdit = false;
  showFilter = false;
  constructor(private searchService: SearchService) { }

  ngOnInit(): void {
    this.searchService.value.subscribe((x)=>{
      console.log("implementar pesquisa");
    })
  }

}
