import { Injector, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})

export class HttpService {
    private headers: any;
    private httpClient: HttpClient

    constructor(private injector: Injector) {
        this.httpClient = this.injector.get(HttpClient);
        this.headers =  new HttpHeaders({
            'Access-Control-Allow-Methods': 'HEAD, GET, POST, PUT, PATCH, DELETE',
            'Content-Type': 'application/json'
            })
    }

    get(url: string): Observable<any> {
        const data = this.httpClient.get<any>(url, { headers: this.headers });
        return data;
    }

    post(url: string, body: any): Observable<any> {
        const data = this.httpClient.post<any>(url, body, { headers: this.headers });

        return data;

    }
}