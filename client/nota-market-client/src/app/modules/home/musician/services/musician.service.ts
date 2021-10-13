import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { GenericHttpService } from 'src/app/core/httpClient/generic-http.service';
import { environment } from 'src/environments/environment';
import { Musician } from '../models/musician.model';

@Injectable({
  providedIn: 'root',
})
export class MusicianService extends GenericHttpService<Musician> {
  constructor(injector: Injector) {
    super(injector, environment.apiUrl + '/api', 'Musician');
  }

  public getMusicianList(): Observable<Musician[]> {
    return this.getList({}, 'Musician');
  }

  public saveMusician(musicianObject: Musician): Observable<any> {
    return this.post(musicianObject, 'SaveMusician');
  }
}
