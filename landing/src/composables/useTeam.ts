import useFetch from "./useFetch";

export default function useTeam() {
  const { data } = useFetch<any[]>("/members");

  return { data };
}
