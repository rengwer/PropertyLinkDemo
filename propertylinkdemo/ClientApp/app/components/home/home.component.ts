import { Component } from '@angular/core';
import { FileService } from '../../services/file.service'

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    constructor(private fileService: FileService) { }

    fileChanged(event: Event) {
        let target: HTMLInputElement = event.target as HTMLInputElement;
        let fileList: FileList|null = target.files;
        if (fileList != null && fileList.length > 0) {
            let file: File = fileList[0];

            this.fileService.uploadFile(file).subscribe(result => alert(result.FileSegments.length), error => alert(error));

            
        }
    }
}
