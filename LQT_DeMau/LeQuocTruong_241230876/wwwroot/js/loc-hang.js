const vungHang = document.querySelector("#danh-sach-hang");
const thongBao = document.querySelector("#loi-loc-hang");

if (vungHang && thongBao) {
    let yeuCauHienTai;

    document.querySelectorAll("[data-loc-hang]").forEach(link => {
        link.addEventListener("click", async event => {
            event.preventDefault();
            yeuCauHienTai?.abort();
            const yeuCau = new AbortController();
            yeuCauHienTai = yeuCau;
            thongBao.textContent = "Đang lọc hàng…";

            try {
                const phanHoi = await fetch(link.href, { signal: yeuCau.signal });
                if (!phanHoi.ok) throw new Error("Lọc hàng thất bại");

                const html = await phanHoi.text();
                if (yeuCau.signal.aborted) return;

                vungHang.innerHTML = html;
                thongBao.textContent = "";
                document.querySelector(".menu li.active")?.classList.remove("active");
                link.closest("li").classList.add("active");
            } catch {
                if (!yeuCau.signal.aborted) {
                    thongBao.textContent = "Không tải được danh sách. Hãy bấm lại.";
                }
            }
        });
    });
}

