import { Injector, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import * as moment_ from 'moment';

export class GenericHttpService<T>  {
    // public headers: HttpHeaders;
    // private ipAddressSub: Subscription;
    // private ipAddress: string;
    private requestHeaders: HttpHeaders;
    private httpClient: HttpClient


    constructor(
        private injector: Injector,
        private url: string,
        private endpoint: string
    )  {
        this.requestHeaders =  new HttpHeaders({
        'Access-Control-Allow-Methods': 'HEAD, GET, POST, PUT, PATCH, DELETE',
        'Content-Type': 'application/json'
        })
        this.httpClient = this.injector.get(HttpClient)
    }

    

    public generateRequestUrl(action: string = '') {
        let generatedPath = `${this.url}`;
        if(this.endpoint !== '') {
            generatedPath = generatedPath + '/' + `${this.endpoint}`;
        }
        if(action !== '') {
            generatedPath = generatedPath + '/' + action;
        }
        return generatedPath;
    }

    public AddExtendedHeaders(httpHeaders?: HttpHeaders) {
        if(httpHeaders != null) {
            httpHeaders.keys().forEach(element => {
                this.requestHeaders = this.requestHeaders.set(element, httpHeaders.get(element));
            });
        }
    }

    public post(item: any, action: string = '', httpParameters?: HttpParams, httpHeaders?: HttpHeaders): Observable<T> {
        this.AddExtendedHeaders(httpHeaders);
        return this.httpClient
            .post<T>(this.generateRequestUrl(action), item, { headers: this.requestHeaders, params: httpParameters })
            .pipe(map(data => data as T));
    }

    public get(id: number, action: string = '',  httpHeaders?: HttpHeaders): Observable<T> {
        this.AddExtendedHeaders(httpHeaders);
        return this.httpClient
            .get<T>(this.generateRequestUrl(action + '/' + id), { headers: this.requestHeaders})
            .pipe(map(data => data as T));
    }

    public getList(queryOptions: any = null, action: string = '',  httpHeaders?: HttpHeaders): Observable<Array<T>> {
        this.AddExtendedHeaders(httpHeaders);
        let fullPath = this.generateRequestUrl(action);
        if (queryOptions) {
            fullPath = `${fullPath}?${Object.keys(queryOptions).map(key => key + '=' + queryOptions[key]).join('&')}`;
        }

        return this.httpClient
            .get<T>(fullPath, { headers: this.requestHeaders})
            .pipe(map((data: any) => data as Array<T>));
    }
}