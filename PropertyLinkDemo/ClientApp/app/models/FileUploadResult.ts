export interface IFileUploadResult {
    fileSegments: Array<IFileSegment>
    programCounts: Array<IProgramCount>
}

export interface IFileSegment {
    headerSegment: IHeaderSegment;
    lineSegments: Array<ILineSegment>;
}

export interface IHeaderSegment {
    text: string;
    dataType: string;
    program: string;
    task: string;
    tool: string;
}


export interface ILineSegment {
    text: string;
    dataType: string;
    program: string;
    task: string;
    tool: string;
    propertyDirection: string;
    sourcePropery: string;
    destinationProperty: string;
}

export interface IProgramCount {
    key: string;
    value: string;
}

