import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  users = [];
  constructor() {}

  ngOnInit() {
    this.users = [
      { id: 19451, name: 'Bill', creation: '2017-11-23', color: 'Red' },
      { id: 86205, name: 'Lottie', creation: '2016-12-26', color: 'Yellow' },
      { id: 14096, name: 'Darla', creation: '2016-10-15', color: 'Purple' },
      { id: 91080, name: 'Graham', creation: '2015-07-14', color: 'Black' },
      { id: 91011, name: 'Brad', creation: '2016-11-26', color: 'Violet' },
      { id: 83962, name: 'Keenan', creation: '2017-08-18', color: 'Orange' },
      { id: 6166, name: 'Jeana', creation: '2017-01-22', color: 'Indigo' },
      { id: 18717, name: 'Debby', creation: '2018-06-21', color: 'Magenta' },
      { id: 55824, name: 'Roslyn', creation: '2016-07-01', color: 'Orange' },
      { id: 24328, name: 'Sheridan', creation: '2016-07-25', color: 'Orange' },
      { id: 39436, name: 'Genoveva', creation: '2015-11-05', color: 'Indigo' }
    ];
  }
}
