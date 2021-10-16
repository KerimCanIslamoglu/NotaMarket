import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/components/dashboard.component';
import { AdminInstrumentTypeListComponent } from './admin-instrument-type-list/components/admin-instrument-type-list/admin-instrument-type-list.component';
import { AdminCreateInstrumentTypeComponent } from './admin-instrument-type-list/components/admin-create-instrument-type/admin-create-instrument-type.component';
import { AdminInstrumentListComponent } from './admin-instrument-list/components/admin-instrument-list/admin-instrument-list.component';
import { AdminCreateInstrumentComponent } from './admin-instrument-list/components/admin-create-instrument/admin-create-instrument.component';
import { AdminMusicianListComponent } from './admin-musician-list/components/admin-musician-list/admin-musician-list.component';
import { AdminCreateMusicianComponent } from './admin-musician-list/components/admin-create-musician/admin-create-musician.component';
import { AdminSheetMusicListComponent } from './admin-sheet-music-list/components/admin-sheet-music-list/admin-sheet-music-list.component';
import { AdminCreateSheetMusicComponent } from './admin-sheet-music-list/components/admin-create-sheet-music/admin-create-sheet-music.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
  },

  {
    path: 'musician-list',
    component: AdminMusicianListComponent,
  },
  {
    path: 'create-musician',
    component: AdminCreateMusicianComponent,
  },

  {
    path: 'sheet-music-list',
    component: AdminSheetMusicListComponent,
  },
  {
    path: 'create-sheet-music',
    component: AdminCreateSheetMusicComponent,
  },

  {
    path: 'instrument-list',
    component: AdminInstrumentListComponent,
  },
  {
    path: 'create-instrument',
    component: AdminCreateInstrumentComponent,
  },

  {
    path: 'instrument-type-list',
    component: AdminInstrumentTypeListComponent,
  },
  {
    path: 'create-instrument-type',
    component: AdminCreateInstrumentTypeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
