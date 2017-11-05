export class FileUploadResult
{
    public FileSegments : Array<FileSegment> 
}

export class FileSegment
{
    public HeaderSegment: HeaderSegment;
    public LineSegments: Array<LineSegment>;
}

export class HeaderSegment implements LineInformation
{
    public Text: string;
}


export class LineSegment implements LineInformation
{
    public Text: string;
}

export interface LineInformation
{
    Text: string;
}

