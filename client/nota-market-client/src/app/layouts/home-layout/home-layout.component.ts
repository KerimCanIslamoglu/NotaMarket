import { Component, OnInit,ChangeDetectionStrategy } from '@angular/core';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-home-layout',
  templateUrl: './home-layout.component.html',
  styleUrls: ['./home-layout.component.css'],
})
export class HomeLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
