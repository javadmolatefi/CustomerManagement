window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const downloadUrl = URL.createObjectURL(blob);

    const anchorElement = document.createElement('a');
    anchorElement.href = downloadUrl;
    anchorElement.download = fileName ?? '';
    anchorElement.click();

    anchorElement.remove();
    URL.revokeObjectURL(downloadUrl);
}
