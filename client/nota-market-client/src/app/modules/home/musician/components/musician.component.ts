import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MusicianService } from '../services/musician.service';

@Component({
  selector: 'app-musician',
  templateUrl: './musician.component.html',
  styleUrls: ['./musician.component.css'],
})
export class MusicianComponent implements OnInit {
  musicians: any[];
  constructor(
    private musicianService: MusicianService,
    private router: Router
  ) {
    this.musicianService.getMusicianList().subscribe((data) => {
      this.musicians = data;
      // this.router.navigate(['/home', {}]);
    });
  }

  ngOnInit(): void {}
}
