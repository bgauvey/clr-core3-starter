import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public items: Item[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Item[]>(baseUrl + 'api/items').subscribe(result => {
      console.log(result);
      this.items = result;
    }, error => console.error(error));
  }
}

interface Item {
    rowId: number;
    itemId: string;
    itemDesc: string;
}
