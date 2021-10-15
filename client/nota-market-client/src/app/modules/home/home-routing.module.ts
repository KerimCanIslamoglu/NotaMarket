import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/components/home.component';
import { MusicianComponent } from './musician/components/musician.component';
import { SheetMusicComponent } from './sheetmusic/components/sheetmusic.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'musician',
    component: MusicianComponent,
  },
  {
    path: 'sheet-musics',
    component: SheetMusicComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
