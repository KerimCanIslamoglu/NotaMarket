import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/components/dashboard.component';
import { AdminMusicianListComponent } from './admin-musician-list/components/admin-musician-list.component';
import { AdminSheetMusicListComponent } from './admin-sheet-music-list/components/admin-sheet-music-list.component';
import { AdminInstrumentListComponent } from './admin-instrument-list/components/admin-instrument-list.component';
import { AdminIntrumentTypeListComponent } from './admin-intrument-type-list/components/admin-intrument-type-list.component';

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
    path: 'sheet-music-list',
    component: AdminSheetMusicListComponent,
  },
  {
    path: 'instrument-list',
    component: AdminInstrumentListComponent,
  },
  {
    path: 'instrument-type-list',
    component: AdminIntrumentTypeListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
