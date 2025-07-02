export interface ApiResponse {
    data: any;
    status: number;
    statusText: string;
    headers: Record<string, string>;
}

export interface PostData {
    [key: string]: any;
}