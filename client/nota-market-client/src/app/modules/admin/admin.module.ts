import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from './dashboard/components/dashboard.component';
import { AdminInstrumentTypeListComponent } from './admin-instrument-type-list/components/admin-instrument-type-list/admin-instrument-type-list.component';
import { AdminCreateInstrumentTypeComponent } from './admin-instrument-type-list/components/admin-create-instrument-type/admin-create-instrument-type.component';
import { AdminCreateInstrumentComponent } from './admin-instrument-list/components/admin-create-instrument/admin-create-instrument.component';
import { AdminInstrumentListComponent } from './admin-instrument-list/components/admin-instrument-list/admin-instrument-list.component';
import { AdminCreateMusicianComponent } from './admin-musician-list/components/admin-create-musician/admin-create-musician.component';
import { AdminMusicianListComponent } from './admin-musician-list/components/admin-musician-list/admin-musician-list.component';
import { AdminSheetMusicListComponent } from './admin-sheet-music-list/components/admin-sheet-music-list/admin-sheet-music-list.component';
import { AdminCreateSheetMusicComponent } from './admin-sheet-music-list/components/admin-create-sheet-music/admin-create-sheet-music.component';

@NgModule({
  declarations: [
    DashboardComponent,
    AdminMusicianListComponent,
    AdminSheetMusicListComponent,
    AdminInstrumentListComponent,
    AdminInstrumentTypeListComponent,
    AdminCreateInstrumentTypeComponent,
    AdminCreateInstrumentComponent,
    AdminCreateMusicianComponent,
    AdminCreateSheetMusicComponent,
  ],
  imports: [CommonModule, AdminRoutingModule],
})
export class AdminModule {}
