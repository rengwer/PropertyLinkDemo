import { Injectable, Inject } from '@angular/core';
import { RequestOptions, RequestMethod, RequestOptionsArgs, Http, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs';
import { IFileUploadResult, IFileSegment, IHeaderSegment, ILineSegment, IProgramCount } from '../models/FileUploadResult'

@Injectable()
export class FileService {
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public uploadFile(file: File): Observable<IFileUploadResult> {
        let formData: FormData = new FormData();
        formData.append('file', file, file.name);

        let headers = new Headers();
        headers.set('Content-Type', 'multipart/form-data');
        headers.append('Accept', 'application/json');

        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.baseUrl + "api/file", file, options)
            .map(result => <IFileUploadResult>result.json());
    }
}