import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from './dashboard/components/dashboard.component';
import { AdminMusicianListComponent } from './admin-musician-list/components/admin-musician-list.component';
import { AdminSheetMusicListComponent } from './admin-sheet-music-list/components/admin-sheet-music-list.component';
import { AdminInstrumentListComponent } from './admin-instrument-list/components/admin-instrument-list.component';
import { AdminIntrumentTypeListComponent } from './admin-intrument-type-list/components/admin-intrument-type-list.component';

@NgModule({
  declarations: [
    DashboardComponent,
    AdminMusicianListComponent,
    AdminSheetMusicListComponent,
    AdminInstrumentListComponent,
    AdminIntrumentTypeListComponent,
  ],
  imports: [CommonModule, AdminRoutingModule],
})
export class AdminModule {}
