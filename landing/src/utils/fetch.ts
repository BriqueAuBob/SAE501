const BASE_URL = import.meta.env.VITE_API_URL;

export default async function fetchData<T>(url: string) {
  if (BASE_URL?.endsWith("/") && url.startsWith("/")) {
    url = url.substring(1);
  }

  if (!BASE_URL?.endsWith("/") && !url.startsWith("/")) {
    url = `/${url}`;
  }

  const response = await fetch(`${BASE_URL}${url}`);
  return (await response.json()) as T;
}
