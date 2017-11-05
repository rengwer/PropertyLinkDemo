import { Injectable, Inject } from '@angular/core';
//import { HttpHeaders } from '@angular/common'
import {
    RequestOptions,
    RequestMethod,
    RequestOptionsArgs,
    Http,
    Headers  } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs';

import { FileUploadResult } from '../models/FileUploadResult'

@Injectable()
export class FileService
{
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public uploadFile(file: File): Observable<FileUploadResult> {
        let formData: FormData = new FormData();
        formData.append('file', file, file.name);
 

        let headers = new Headers();
        //headers.append('Content-Type', 'application/json');
        headers.set('Content-Type', 'multipart/form-data');
        headers.append('Accept', 'application/json');
        
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.baseUrl + "api/file", file, options)
            .map(result => { debugger; return result.json() as FileUploadResult;});
    }
}