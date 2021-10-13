import { Component, OnInit } from '@angular/core';
import { MusicianService } from './musician.service';

@Component({
  selector: 'app-musician',
  templateUrl: './musician.component.html',
  styleUrls: ['./musician.component.css']
})
export class MusicianComponent implements OnInit {
  musicians: any[];
  constructor(private musicianService: MusicianService) {
     this.musicianService.getMusicianList().subscribe(data => {
       this.musicians = data
     });
   }

  ngOnInit(): void {
  }

}
