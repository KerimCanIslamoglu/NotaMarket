import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home/components/home.component';
import { MusicianComponent } from './musician/components/musician.component';
import { SheetMusicComponent } from './sheetmusic/components/sheetmusic.component';

@NgModule({
    declarations: [
    
    HomeComponent,
    MusicianComponent,
    SheetMusicComponent
  ],
    imports: [
        CommonModule,
        HomeRoutingModule,
    ]
})
export class HomeModule { }