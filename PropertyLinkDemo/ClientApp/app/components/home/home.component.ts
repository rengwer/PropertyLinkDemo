import { Component, OnInit } from '@angular/core';
import { FileService } from '../../services/file.service'
import { IFileUploadResult, IFileSegment, IHeaderSegment, ILineSegment, IProgramCount } from '../../models/FileUploadResult'
import { Observable } from 'rxjs';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    public fileUploadResult: IFileUploadResult
    constructor(private fileService: FileService) { }

    fileChanged(event: Event) {
        let target: HTMLInputElement = event.target as HTMLInputElement;
        let fileList: FileList | null = target.files;
        if (fileList != null && fileList.length > 0) {
            let file: File = fileList[0];
            this.fileService.uploadFile(file).subscribe(
                result => this.fileUploadResult = result,
                error => alert(error)
            );
        }
    }
}
